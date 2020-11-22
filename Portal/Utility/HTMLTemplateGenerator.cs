using Portal.Context;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Utility
{
    public class HTMLTemplateGenerator
    {
        private Applicant _applicant;
        private MyContext _myContext;
        public HTMLTemplateGenerator(Applicant applicant)
        {
            _applicant = applicant;
        }

        //public string GetHTMLString()
        //{
        //    var sb = new StringBuilder();
        //    sb.Append(@"
        //                <html>
        //                    <head>
        //                    </head>
        //                    <body>
        //                        <div class='header'><h1>This is the generated PDF report!!!</h1></div>
        //                        <table align='center'>");

        //    sb.AppendFormat(@"
        //                        <p>
        //                        Posisi      : {0}<br>
        //                        Referensi   : {1}<br>
        //                        Skill       : ", _applicant.Position.Name, _applicant.Reference.Name);


        //    foreach (var item in _applicant.Skills)
        //    {
        //        sb.AppendFormat(@"{0}, ", item.Name);
        //    }

        //    sb.Append(@"</p>
        //                        </table>
        //                    </body>
        //                </html>");
        //    return sb.ToString();
        //}

        public string GetHTMLString()
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                                <meta charset='UTF-8'>
                                <meta name='viewport' content='witdh=device-width, initial-scale=1.0'>
                                <meta http-equiv='X-UA-Compatible' content='ie-edge'>

                                <link rel='preconnect' href='https://fonts.gstatic.com'>
                                <link href='https://fonts.googleapis.com/css2?family=Lato:wght@300;400&display=swap' rel='stylesheet'> 

                                <script src='https://unpkg.com/feather-icons'></script>

                                <title></title>
                            </head>
                            <body>
                                <div class='header'>
                                    <div class='header_name'>Dionisius Yose Deofili Abadi</div>");

            sb.AppendFormat(@"
                                    <div class='header_position'>{0}</div>", _applicant.Position.Name);

            sb.Append(@"
                                </div>
                                <div class='flex '>
                                    <div class='flex flex__container'>
                                        <i class='flex__icon' data-feather='mail'></i>
                                        dionisiusyose11@gmail.com
                                    </div>
            
                                    <div class='flex flex__container'>
                                        <i class='flex__icon' data-feather='phone'></i>
                                        +6282242275560
                                    </div>
                                </div>

                                <div class='personal'>
                                    <h2>Data Pribadi</h2>
                                    <div class='flex flex_-container'>
                                        <div class='personal_label personal__container'>Tanggal lahir</div>
                                        <div>: 11 Oktober 1997 </div>
                                    </div>
                                    <div class='flex flex_-container '>
                                        <div class='personal_label personal__container'>Jenis Kelamin</div>
                                        <div>: Laki - laki </div>
                                    </div>
                                    <div class='flex flex_-container'>
                                        <div class='personal_label personal__container'>Agama</div>
                                        <div>: Katholik </div>
                                    </div>
                                </div>

                                <div class='personal'>
                                    <h2>Data Pendidikan</h2>
                                    <div class='flex flex_-container'>
                                        <div class='personal_label personal__container'>Asal Kampus/ Sekolah</div>
                                        <div>: Institut Teknologi Sepuluh Nopember </div>
                                    </div>
                                    <div class='flex flex_-container'>
                                        <div class='personal_label personal__container'>Asal Departemen</div>
                                        <div>: Teknik Elektro </div>
                                    </div>
                                    <div class='flex flex_-container'>
                                        <div class='personal_label personal__container'>Jenjang</div>
                                        <div>: Strata-1 </div>
                                    </div>
                                    <div class='flex flex_-container'>
                                        <div class='personal_label personal__container'>Tahun lulus</div>
                                        <div>: 2020 </div>
                                    </div>
                                    <div class='flex flex_-container'>
                                        <div class='personal_label personal__container'>IPK</div>
                                        <div>: 3.35 </div>
                                    </div>
                                </div>
                                <div class='personal'>
                                    <h2>Informasi Lain</h2>
                                    <div class='flex flex_-container'>
                                        <div class='personal_label personal__container'>Referensi</div>");

            sb.AppendFormat(@"
                                        <div>: {0} </div>", _applicant.Reference.Name);

            sb.Append(@"
                                    </div>
                                    <div class='flex flex_-container personal__list'>
                                        <div class='personal_label personal__container'>Keahlian</div>
                                        <div>: </div>
                                    </div>
                                    <ul class='personal'>");

            foreach (var item in _applicant.Skills)
            {
                sb.AppendFormat(@"
                                        <li>{0}</li> ", item.Name);}

            sb.Append(@"
                                    </ul> 
                                </div>
                            </body>	

                            <script>
                                feather.replace()
                                </script>
                        </html>");
            return sb.ToString();
        }
    }
}
