using Portal.Context;
using Portal.Models;
using Portal.ViewModel;
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
        private ApplicantVM _applicantVM;
        public HTMLTemplateGenerator(Applicant applicant, ApplicantVM applicantVM)
        {
            _applicant = applicant;
            _applicantVM = applicantVM;
        }

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
                                <div class='header'>");

            sb.AppendFormat("       <div class='header_name'>{0} {1}</div>", _applicantVM.FirstName, _applicantVM.LastName);

            sb.AppendFormat(@"
                                    <div class='header_position'>{0}</div>", _applicant.Position.Name);

            sb.AppendFormat(@"
                                </div>
                                <div class='flex '>
                                    <div class='flex flex__container'>
                                        <i class='flex__icon' data-feather='mail'></i>
                                        {0}
                                    </div>", _applicantVM.Email);

            sb.AppendFormat(@"            
                                    <div class='flex flex__container'>
                                        <i class='flex__icon' data-feather='phone'></i>
                                        {0}
                                    </div>
                                </div>", _applicantVM.Phone);

             sb.AppendFormat(@" <div class='personal'>
                                    <h2>Data Pribadi</h2>
                                    <div class='flex flex_-container'>
                                        <div class='personal_label personal__container'>Tanggal lahir</div>
                                        <div>: {0} </div>
                                    </div>
                                    <div class='flex flex_-container '>
                                        <div class='personal_label personal__container'>Jenis Kelamin</div>
                                        <div>: {1} </div>
                                    </div>
                                    <div class='flex flex_-container'>
                                        <div class='personal_label personal__container'>Agama</div>
                                        <div>: {2} </div>
                                    </div>
                                </div>

                                <div class='personal'>
                                    <h2>Data Pendidikan</h2>
                                    <div class='flex flex_-container'>
                                        <div class='personal_label personal__container'>Asal Kampus/ Sekolah</div>
                                        <div>: {3} </div>
                                    </div>
                                    <div class='flex flex_-container'>
                                        <div class='personal_label personal__container'>Asal Departemen</div>
                                        <div>: {4} </div>
                                    </div>
                                    <div class='flex flex_-container'>
                                        <div class='personal_label personal__container'>Jenjang</div>
                                        <div>: {5} </div>
                                    </div>
                                    <div class='flex flex_-container'>
                                        <div class='personal_label personal__container'>Tahun lulus</div>
                                        <div>: {6} </div>
                                    </div>
                                    <div class='flex flex_-container'>
                                        <div class='personal_label personal__container'>IPK</div>
                                        <div>: {7} </div>
                                    </div>
                                </div>
                                <div class='personal'>
                                    <h2>Informasi Lain</h2>
                                    <div class='flex flex_-container'>
                                        <div class='personal_label personal__container'>Referensi</div>", 
                                        _applicantVM.BirthDate.ToString("dd MMMM yyyy"), _applicantVM.Gender, _applicantVM.Religion, _applicantVM.University,
                                        _applicantVM.Department, _applicantVM.Degree, _applicantVM.GraduationYear, _applicantVM.GPA
                                        );

            sb.AppendFormat(@"
                                        <div>: {0} </div>", _applicant.Reference.Name);

            List<string> arraySkill = new List<string>();
            foreach (var item in _applicant.Skills)
            {
                arraySkill.Add(item.Name);
            }

            string SkillList = string.Join(", ", arraySkill);

            sb.AppendFormat(@"
                                    </div>
                                    <div class='flex flex_-container'>
                                        <div class='personal_label personal__container'>Keahlian</div>
                                        <div>: </div>
                                    </div>
                                    <div> {0}", SkillList);

            sb.Append(@"
                                    
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
