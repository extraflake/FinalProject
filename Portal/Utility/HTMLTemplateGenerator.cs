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
        public HTMLTemplateGenerator(Applicant applicant)
        {
            _applicant = applicant;
        }

        public string GetHTMLString()
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <table align='center'>");

            sb.AppendFormat(@"
                                <p>
                                Posisi      : {0}<br>
                                Referensi   : {1}<br>
                                Skill       : ", _applicant.Position.Name, _applicant.Reference.Name);


            foreach (var item in _applicant.Skills)
            {
                sb.AppendFormat(@"{0}, ", item.Name);
            }

            sb.Append(@"</p>
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
    }
}
