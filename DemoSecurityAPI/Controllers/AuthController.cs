using DemoSecurityAPI.Dto;
using DemoSecurityAPI.Infrasctructure;
using DemoSecurityAPI.Mapper;
using DemoSecurityBll.Interfaces;
using DemoSecurityDal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoSecurityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _IUserService;
        private readonly TokenManager _tokenManager;

        public AuthController(IUserService iuserService, TokenManager tokenManager)
        {
            _IUserService = iuserService;
            _tokenManager = tokenManager;
        }

        // Register
        [HttpPost(nameof(Register))]
        public IActionResult Register(UserRegisterForm form)
        {
            try
            {
                // Vérifie si le modèle de données est valide
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                // Appelle le service pour enregistrer l'user
                _IUserService.RegisterUser(form.ApiToBll());

                // Retorune une réponse avec succès
                return Ok("Utilisateur enregistré avec succès !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Login
        [HttpPost(nameof(Login))]

        public IActionResult Login(UserLoginForm form)
        {
            try
            {
                // Vérifie si le modèle de données est valide
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                UserModel currentUser = _IUserService.LoginUser(form.Email, form.Password);

                if (currentUser is null)
                {
                    return BadRequest("L'utilisateur n'existe pas...");
                }

                string token = _tokenManager.GenerateJwt(currentUser);

                return Ok(token);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet(nameof(TestRouteConnected))]
        [Authorize]
        public IActionResult TestRouteConnected()
        {
            return Ok("Accès autorisé pour les personnes connectées peut importe le role");
        }

        [HttpGet(nameof(TestRouteUser))]
        [Authorize(Roles = "1")]
        public IActionResult TestRouteUser()
        {
            return Ok("Accès autorisé pour les utilisateurs");
        }

        [HttpGet(nameof(TestRouteModo))]
        [Authorize(Roles = "2")]
        public IActionResult TestRouteModo()
        {
            return Ok("Accès autorisé pour les Modo");
        }

        [HttpGet(nameof(TestRouteAdmin))]
        [Authorize(Roles = "3")]
        public IActionResult TestRouteAdmin()
        {
            return Ok("Accès autorisé pour les Admin");
        }
    }
}