using Agenda.Service.Dto;
using Agenda.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Agenda.Controllers
{
    public class ServicoController : Controller
    {        
        ServicoService Service = new ServicoService();

        public IActionResult NewService()
        {
            try
            {
                return View("Servico", new ServicoDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult GetServicoById(int id)
        {
            try
            {
                return View(Service.GetServicoById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult GetAllServico()
        {
            try
            {
                return View(Service.GetAllServicos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult SubmitServico(ServicoDto servicodto)
        {
            try
            {
                Service.SubmitServico(servicodto);
                return Ok("Servico Cadastrado com Sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
