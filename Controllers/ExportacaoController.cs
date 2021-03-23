using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Exportacao.Models;
namespace Exportacao.Controllers
{
    public class ExportacaoController : Controller
    {
        //localhost:5001/Exportacao/Cadastro
        public IActionResult Cadastro(){
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult Cadastro(string volume, string numero, string data, string valor){
            if(ModelState.IsValid){
                Console.WriteLine("Número do reg: "+ numero);
                Console.WriteLine("Data: "+ Convert.ToDateTime(data));
                Console.WriteLine("Volume: "+ volume);
                Console.WriteLine("Valor: "+ valor);
                float valor1 = float.Parse(valor);
                DateTime data1 = Convert.ToDateTime(data);
                if(data1.Month == 3){
                    valor1 = valor1 - (valor1 * 0.2f);
                }
                TempData["numero"] = numero;
                TempData["valor"] = valor1.ToString();
                TempData["data"] = data;
                TempData["volume"] = volume;



            }

            return RedirectToAction(actionName: "Detalhes");
        }
        public IActionResult Detalhes(){
            return View();
        }
    }
}