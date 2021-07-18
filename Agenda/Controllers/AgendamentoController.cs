using Agenda.Service.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using Agenda.Service.Services;



namespace Agenda.Controllers
{
    public class AgendamentoController : Controller
    {
        AgendamentoService Service = new AgendamentoService();
        public IActionResult Index()
        {
            return View("Index", Service.GetAllAgendamentos());
        }

        public IActionResult NewAgendamento()
        {            
            try
            {
                return View("Agendamento", Service.GetNewAgendamento());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult UpdateAgendamento(int id)
        {
            try
            {
                return View("Agendamento", Service.GetAgendamentoById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult SubmitAgendamento(AgendamentoFormDto agendamentodto)
        {
            try
            {
                Service.SubmitAgendamento(agendamentodto);
                return Ok("Agendamento Cadastrado com Sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
