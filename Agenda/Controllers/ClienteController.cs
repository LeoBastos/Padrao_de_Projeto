using Agenda.Service.Dto;
using Agenda.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Agenda.Controllers
{
    public class ClienteController : Controller
    {
        ClienteService Service = new ClienteService();

        public IActionResult Index()
        {
            try
            {
                return View("Index", Service.GetAllClientes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult NewCliente()
        {
            try
            {
                return View("Cliente", new ClienteDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }       

        public IActionResult UpdateCliente(int id)
        {
            try
            {
                return View("Cliente", Service.GetClienteById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult GetClienteById(int id)
        {
            try
            {
                return View("ViewCliente", Service.GetClienteById(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }        

        public IActionResult SubmitCliente(ClienteDto clientedto)
        {
            try
            {
                Service.SubmitCliente(clientedto);
                return Ok("Cliente Cadastrado com Sucesso.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }       
    }
}
