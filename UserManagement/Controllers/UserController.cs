using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UserManagement.BusinessLogic.Filters;
using UserManagement.BusinessLogic.Interface;
using UserManagement.BusinessLogic.Mapper;
using UserManagement.BusinessLogic.Models;
using UserManagement.BusinessLogic.Services;
using UserManagement.DataAccess.Models;
using UserManagement.Mapper;
using UserManagement.Models;
using UserManagement.Validation;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService _userService;
        public IRoleService _roleService;
        private IMapper _mapper;
        private IValidator<UserViewModel> _userValidator;
        private IValidator<RoleViewModel> _roleValidator;
        public UserController(IUserService userService, IRoleService roleService,IValidator<UserViewModel> userValidator, IValidator<RoleViewModel> roleValidator)
        {
            this._userService = userService;
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            var mapper = config.CreateMapper();
            _mapper = mapper;
            _userValidator = userValidator;
            _roleValidator = roleValidator;
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]UsersFilter filter)
        {
            var users = _userService.GetAllUsers(filter);
            return Ok(users) ;
        }   

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUserById(id);
            if(user != null)
            {
                return Ok(user);
            }
            return Content($"Пользователь с id {id} отсутствует"); ;
        }

        [HttpGet("{id}/Roles")]
        public IActionResult GetUserRolesByUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user != null)
            {
                return Ok(user.Roles);
            }   
            return StatusCode(404);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromQuery] UserViewModel model)
        {
            ValidationResult result = await _userValidator.ValidateAsync(model);
            if (result.IsValid)
            {
                var userWithEmail = _userService.GetUsersByEmail(model.Email);
                if (userWithEmail != null)
                {
                    return Content("Пользователь с таким email уже существует");
                }
                else
                {
                    var userModel = _mapper.Map<UserModel>(model);
                    _userService.AddUser(userModel);
                    return Content($"Пользователь {model.Name} добавлен");
                }  
            }
            else
            {
                 result.AddToModelState(this.ModelState);
                 return BadRequest(ModelState);
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> AddRoleForUser([FromQuery] RoleViewModel model, int id)
        {
            ValidationResult result = await _roleValidator.ValidateAsync(model);
            if (result.IsValid)
            {
                var user = _userService.GetUserById(id);
                if (user != null)
                {
                    var roleModel = _mapper.Map<RoleModel>(model);
                    if (user.Roles.Contains(roleModel))
                    {
                        return Content($"У пользователя {user.Name} есть роль {model.RoleName}");
                    }
                    else
                    {
                        var role = _roleService.GetRoleByName(model.RoleName);
                        if(role != null)
                        {
                            _userService.AddRoleForUser(role, user);
                            return Ok($"Роль {model.RoleName} добавлена пользователю {user.Name}");
                        }
                        return Content($"Такой роли не существует");
                    }
                }
                else
                {
                    return Content($"Пользователь не найден");
                }
                  
            }
            else
            {
                result.AddToModelState(this.ModelState);
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userService.GetUserById(id);
            if(user != null)
            {
                _userService.DeleteUser(id);
                return Content($"Пользователь {user.Name} удален");
            }
            return StatusCode(404);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromQuery] UserViewModel model)
        {
            ValidationResult result = await _userValidator.ValidateAsync(model);
            if (result.IsValid)
            {
                var userModel = _mapper.Map<UserModel>(model);
                _userService.UpdateUser(userModel);
                return Ok($"Пользователь {model.Name} обновлен");
            }
            else
            {
                result.AddToModelState(this.ModelState);
                return BadRequest(ModelState);
            }
        }
    }
}
