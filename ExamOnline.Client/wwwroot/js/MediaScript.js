'use strict';

let mediaRecorder;
let recordedBlobs;

const gumVideo = document.querySelector('video#gum');

var btn = document.getElementById('nextBtn');
var segments = JSON.parse(sessionStorage.getItem("segments"));
debugger;
if (sessionStorage.getItem("done")) {
    stopRecording();
    playVideo();
}

function playVideo() {
    const superBuffer = new Blob(recordedBlobs, { type: 'video/webm' });
    gumVideo.src = null;
    gumVideo.srcObject = null;
    gumVideo.src = window.URL.createObjectURL(superBuffer);
    gumVideo.controls = true;
    gumVideo.play();
}


function handleDataAvailable(event) {
    console.log('handleDataAvailable', event);
    if (event.data && event.data.size > 0) {
        recordedBlobs.push(event.data);
    }
}

function startRecording() {
    recordedBlobs = [];
    let options = { mimeType: 'video/webm;codecs=vp9,opus' };
    try {
        mediaRecorder = new MediaRecorder(window.stream, options);
    } catch (e) {
        console.error('Exception while creating MediaRecorder:', e);
        return;
    }

    console.log('Created MediaRecorder', mediaRecorder, 'with options', options);
    mediaRecorder.onstop = (event) => {
        console.log('Recorder stopped: ', event);
        console.log('Recorded Blobs: ', recordedBlobs);
    };
    mediaRecorder.ondataavailable = handleDataAvailable;
    mediaRecorder.start();
    console.log('MediaRecorder started', mediaRecorder);
}

function stopRecording() {
    mediaRecorder.stop();
}

function handleSuccess(stream) {
    console.log('getUserMedia() got stream:', stream);
    window.stream = stream;
    startRecording();
    gumVideo.srcObject = stream;
}

async function init(constraints) {
    try {
        const stream = await navigator.mediaDevices.getUserMedia(constraints);
        handleSuccess(stream);
    } catch (e) {
        console.log('navigator.getUserMedia error:', e);
    }
}

$(document).ready(async function () {
    const constraints = {
        audio: {
            echoCancellation: { exact: true }
        },
        video: {
            width: 480, height: 240
        }
    };
    console.log('Using media constraints:', constraints);
    await init(constraints);
});

