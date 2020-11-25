using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UserManagement.Dapper_ORM.Services;
using UserManagement.Microservices.Context;
using UserManagement.ViewModel;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly IDapper _dapper;
        public IConfiguration _configuration;
        private readonly MyContext _myContext;

        public AccountsController(IConfiguration configuration, IDapper dapper, MyContext myContext)
        {
            _myContext = myContext;
            _configuration = configuration;
            _dapper = dapper;
        }

        [HttpPost(nameof(Get))]
        public async Task<string> Get(RegisterVM userroleVM)
        {
            try
            {
                var dbparams = new DynamicParameters();
                dbparams.Add("@User_Email", userroleVM.User_Email, DbType.String);
                dbparams.Add("@Username", userroleVM.Username, DbType.String);
                dbparams.Add("@Phone", userroleVM.Phone, DbType.String);
                var result = await Task.FromResult(_dapper.Get<RegisterVM>("[dbo].[SP_Login_UserRole]",
                    dbparams, commandType: CommandType.StoredProcedure));

                var getApplication = _myContext.UserApplications.Where(x => x.UserId == result.UserID).ToList();
                List<string> arrayApp = new List<string>();
                foreach(var item in getApplication)
                {
                    var getApplicationName = _myContext.Applications.Where(x => x.Id == i9mtem.ApplicationId).FirstOrDefault();
                    arrayApp.Add(getApplicationName.Name);
                }

                string Applications = string.Join(",", arrayApp);

                if (BCrypt.Net.BCrypt.Verify(userroleVM.User_Password, result.User_Password))
                {
                    var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("User_Email", result.User_Email),
                    new Claim("Role_Name", result.Role_Name),
                    new Claim("Username", result.Username),
                    new Claim("UserApplication", Applications),
                    new Claim("EmployeeId", result.EmployeeId.ToString()),
                    new Claim("UserID", result.UserID.ToString())
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
                return "Error";
            }
            catch (Exception)
            {
                return "Error";
            }
        }

        [HttpPost(nameof(RegisterBC))]
        public async Task<int> RegisterBC(RegisterVM data)
        {

            try
            {
                var password = data.User_Password;
                data.User_Password = BCrypt.Net.BCrypt.HashPassword(password);

                var dbparams = new DynamicParameters();
                dbparams.Add("FirstName", data.FirstName, DbType.String);
                dbparams.Add("LastName", data.LastName, DbType.String);
                dbparams.Add("User_Email", data.User_Email, DbType.String);
                dbparams.Add("User_Password", data.User_Password, DbType.String);
                dbparams.Add("Username", data.Username, DbType.String);
                dbparams.Add("Phone", data.Phone, DbType.String);
                dbparams.Add("BirthDate", data.BirthDate, DbType.Date);
                dbparams.Add("Gender", data.Gender, DbType.String);
                dbparams.Add("ReligionID", data.ReligionID, DbType.Int32);
                var result = await Task.FromResult(_dapper.Insert<int>("[dbo].[SP_InsertRegisterBC]", dbparams, commandType: CommandType.StoredProcedure));
                return result;
            }
            catch (Exception)
            {
                var result = 404;
                return result;
            }
        }

        [HttpPost(nameof(RegisterAdmin))]
        public async Task<int> RegisterAdmin(RegisterVM data)
        {
            try
            {
                var password = data.User_Password;
                data.User_Password = BCrypt.Net.BCrypt.HashPassword(password);

                var dbparams = new DynamicParameters();
                dbparams.Add("FirstName", data.FirstName, DbType.String);
                dbparams.Add("LastName", data.LastName, DbType.String);
                dbparams.Add("User_Email", data.User_Email, DbType.String);
                dbparams.Add("User_Password", data.User_Password, DbType.String);
                dbparams.Add("Username", data.Username, DbType.String);
                dbparams.Add("Phone", data.Phone, DbType.String);
                dbparams.Add("BirthDate", data.BirthDate, DbType.Date);
                dbparams.Add("Gender", data.Gender, DbType.String);
                dbparams.Add("ReligionID", data.ReligionID, DbType.Int32);
                dbparams.Add("Role_RoleId", data.Role_RoleId, DbType.Int32);

                var result = await Task.FromResult(_dapper.Insert<int>("[dbo].[SP_InsertRegisterAdmin]", dbparams, commandType: CommandType.StoredProcedure));
                return result;
            }
            catch (Exception)
            {
                var result = 404;
                return result;
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut(nameof(ChangePassword))]
        public async Task<int> ChangePassword(RegisterVM data)
        {
            try
            {
                var dbparams = new DynamicParameters();
                if (data.User_Password == string.Empty)
                {
                    return 404;
                }
                data.User_Password = BCrypt.Net.BCrypt.HashPassword(data.User_Password);
                dbparams.Add("@User_Email", data.User_Email, DbType.String);
                dbparams.Add("@User_Password", data.User_Password, DbType.String);
                var find = await _myContext.Users.SingleOrDefaultAsync(x => x.Email == data.User_Email);
                if (find != null)
                {
                    var updateUser = await Task.FromResult(_dapper.Update<int>("[dbo].[SP_Update_User]",
                                dbparams,
                                commandType: CommandType.StoredProcedure));
                    return updateUser;
                }
                return 404;
            }
            catch (Exception)
            {
                return 404;
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut(nameof(EditProfile))]
        public async Task<int> EditProfile(EditProfileVM data)
        {
            try
            {
                var dbparams = new DynamicParameters();
                dbparams.Add("@FirstName", data.FirstName, DbType.String);
                dbparams.Add("@LastName", data.LastName, DbType.String);
                dbparams.Add("@BirthDate", data.BirthDate, DbType.Date);
                dbparams.Add("@Gender", data.Gender, DbType.String);
                dbparams.Add("@ReligionId", data.ReligionId, DbType.Int32);
                dbparams.Add("@EmployeeId", data.EmployeeId, DbType.Int32);
                dbparams.Add("@User_Email", data.User_Email, DbType.String);
                dbparams.Add("@Phone", data.Phone, DbType.String);
                dbparams.Add("@UserId", data.UserId, DbType.Int32);
                dbparams.Add("@UniversityId", data.UniversityId, DbType.String);
                dbparams.Add("@DepartmentId", data.DepartmentId, DbType.String);
                dbparams.Add("@GPA", data.GPA, DbType.String);
                dbparams.Add("@Degree", data.Degree, DbType.String);
                dbparams.Add("@GraduateYear", data.GraduateYear, DbType.String);


                var editprofile = await Task.FromResult(_dapper.Update<int>("[dbo].[SP_EditProfile]",
                            dbparams,
                            commandType: CommandType.StoredProcedure));
                return editprofile;
            }
            catch (Exception)
            {
                return 404;
            }
        }

        [HttpPatch]
        public async Task<int> Forgot(RegisterVM entity)
        {
            try
            {
                Guid id = Guid.NewGuid();
                string guid = id.ToString();
                var dbparams = new DynamicParameters();
                dbparams.Add("@User_Email", entity.User_Email, DbType.String);
                dbparams.Add("@User_Password", BCrypt.Net.BCrypt.HashPassword(guid), DbType.String);

                var find = await _myContext.Users.SingleOrDefaultAsync(x => x.Email == entity.User_Email);

                if (find != null)
                {
                    var result = await Task.FromResult(_dapper.Update<int>("[dbo].[SP_Update_User]", dbparams,
                    commandType: CommandType.StoredProcedure));

                    MailMessage mm = new MailMessage("e2ftspen.ga@gmail.com", entity.User_Email.ToString());
                    mm.Subject = "Reset Your Password ! " + DateTime.Now.ToString();
                    mm.Body = string.Format("Hello is your email " + entity.User_Email.ToString() + " your password is " + guid);
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential nc = new NetworkCredential();
                    nc.UserName = "e2ftspen.ga@gmail.com";
                    nc.Password = "smpn3cilegon";
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = nc;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    return result;
                }
                return 404;
            }
            catch (Exception)
            {
                return 404;
            }
        }

        [HttpPost(nameof(CheckEmail))]
        public async Task<string> CheckEmail(RegisterVM userroleVM)
        {
            try
            {
                var dbparams = new DynamicParameters();

                dbparams.Add("@User_Email", userroleVM.User_Email, DbType.String);
                var result = await Task.FromResult(_dapper.Get<RegisterVM>("[dbo].[SP_CheckEmail]",
                    dbparams, commandType: CommandType.StoredProcedure));

                if (result.User_Email == userroleVM.User_Email)
                {
                    return "Email sudah ada. Tidak boleh memasukkan email yang sama!";
                }
                return "Error";
            }
            catch (Exception)
            {
                return "Email bisa digunakan";
            }

        }

        [HttpPost(nameof(CheckUsername))]
        public async Task<string> CheckUsername(RegisterVM userroleVM)
        {
            try
            {
                var dbparams = new DynamicParameters();

                dbparams.Add("@Username", userroleVM.Username, DbType.String);
                var result = await Task.FromResult(_dapper.Get<RegisterVM>("[dbo].[SP_CheckUsername]",
                    dbparams, commandType: CommandType.StoredProcedure));

                if (result.Username == userroleVM.Username)
                {
                    return "Username sudah ada. Tidak boleh memasukkan username yang sama!";
                }
                return "Error";
            }
            catch (Exception)
            {
                return "Username bisa digunakan";
            }

        }

        [HttpPost(nameof(CheckPhone))]
        public async Task<string> CheckPhone(RegisterVM userroleVM)
        {
            try
            {
                var dbparams = new DynamicParameters();

                dbparams.Add("@Phone", userroleVM.Phone, DbType.String);
                var result = await Task.FromResult(_dapper.Get<RegisterVM>("[dbo].[SP_CheckPhone]",
                    dbparams, commandType: CommandType.StoredProcedure));

                if (result.Phone == userroleVM.Phone)
                {
                    return "No HP sudah ada. Tidak boleh memasukkan No HPyang sama!";
                }
                return "Error";
            }
            catch (Exception)
            {
                return "No HP bisa digunakan";
            }

        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet(nameof(CountUniversity))]
        public List<CountVM> CountUniversity()
        {
            var result = (_dapper.GetAll<CountVM>($"select u.Name as University, count(e.UniversityId) as Total from TB_T_Education e join TB_M_University u on e.UniversityId = u.Id group by u.Name", null, commandType: CommandType.Text));
            return result;
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet(nameof(CountDepartment))]
        public List<CountVM> CountDepartment()
        {
            var result = (_dapper.GetAll<CountVM>($"select d.Name as Department, count(e.DepartmentId) as Total from TB_T_Education e join TB_M_Department d on e.DepartmentId = d.Id group by d.Name", null, commandType: CommandType.Text));
            return result;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet(nameof(CountUser))]
        public List<CountVM> CountUser()
        {
            var result = (_dapper.GetAll<CountVM>($"select count(Id) as Total from TB_M_User", null, commandType: CommandType.Text));
            return result;
        }
    }
}
