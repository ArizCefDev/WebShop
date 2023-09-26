using AutoMapper;
using Business.Abstract;
using DataAccess.Context;
using DataAccess.Entity;
using DTO.DTOEntity;
using Helper.Constants;
using Helper.CookieCrypto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService:BaseService<UserDTO,User,UserDTO>,IUserService
    {
        public UserService(IMapper mapper,AppDbContext appDbContext) : base(mapper, appDbContext) 
        {
        }

        public UserDTO Login(UserDTO model)
        {
            var res = _appDbContext.Users
            .Where(x => x.UserName == model.UserName)
             .Include(u => u.Role);

            if (res.Count() == 1)
            {
                var user = res.FirstOrDefault();

                var hash = Crypto.GenerateSHA256Hash(model.Password, user.Salt);

                if (hash == user.PasswordHash)
                {
                    var dto = _mapper.Map<User, UserDTO>(res.First());
                    return dto;
                }
                else
                {
                    throw new Exception("Şifrə yalnışdır!");
                }
            }
            else
            {
                throw new Exception("Hesab mövcud deyil");
            }
        }

        public override UserDTO Insert(UserDTO dto)
        {
            var res = _appDbContext.Users.Where(x => x.UserName == dto.UserName);
            var resmail = _appDbContext.Users.Where(x => x.Email == dto.Email);

            var role = _appDbContext.Roles.Where(x => x.Name == RoleKeywords.UserRole)?.First();
            dto.RoleId = role.ID;

            if (res.Any())
            {
                throw new Exception("Bu istifadəçi adı mövcuddur!");
            }
            if (resmail.Any())
            {
                throw new Exception("Bu gmail adı mövcuddur!");
            }


            dto.Salt = Crypto.GenerateSalt();
            dto.PasswordHash = Crypto.GenerateSHA256Hash(dto.Password, dto.Salt);

            return base.Insert(dto);
        }
    }
}
