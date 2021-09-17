using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WSVentas.Models;
using WSVentas.Models.Request;
using WSVentas.Models.Response;

namespace WSVentas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(){
            Response oResponse =  new Response();
            try{
                using (ModelContext db = new ModelContext()){
                    List<Cliente> lst = db.Clientes.ToList();
                    oResponse.success = 1;
                    oResponse.data = lst;
                } 

            }catch(Exception ex){
                oResponse.message = ex.Message;
            }

            return Ok(oResponse);
        }

        [HttpPost]
        public IActionResult SendClient(ClientRequest rClient){
            Response oResponse = new Response();

            try{
                using(ModelContext db = new ModelContext()){
                    oResponse.success = 1;
                    Cliente cliente = new Cliente();
                    cliente.Nombre = rClient.nombre;
                    oResponse.data = cliente;
                    db.Clientes.Add(cliente);
                     db.SaveChanges();
                }
            }catch(Exception ex){
                oResponse.message = ex.Message;
            }

            return Ok(oResponse);
        }

        [HttpPut]
        public IActionResult edit(ClientRequest rClient){
            Response oResponse = new Response();

            try{
                using(ModelContext db = new ModelContext()){
                    Cliente cliente = db.Clientes.Find(rClient.id);
                    cliente.Nombre = rClient.nombre;
                    db.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oResponse.success = 1;
                    oResponse.data = cliente;
                }
            }catch(Exception e){
                oResponse.message = e.Message;
            }
            return Ok(oResponse);
        }

        [HttpDelete]
        public IActionResult delete(ClientRequest rClient){
            Response oResponse = new Response();

            try{
                using(ModelContext db = new ModelContext()){
                    Cliente cliente = db.Clientes.Find(rClient.id);
                    db.Remove(cliente);
                    db.SaveChanges();
                    oResponse.success = 1;
                    oResponse.data = cliente;
                }

            }catch(Exception e){
                oResponse.message = e.Message;
                return Ok(oResponse);
            }
            return Ok(oResponse);
        }
    }
}