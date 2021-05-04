using AcfLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace AcfLib.Filters
{
    public class ExceptionFilters : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MinValue;
        List<Erro> erros = new List<Erro>();

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                context.ExceptionHandled = true;
                erros.Clear();

                erros.Add(new Erro(string.Empty, context.Exception.Message.Replace(" (Parameter '", "").Replace("')", "")));

                context.Result = new ObjectResult(null)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Value = erros
                };
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var modelErrors = context.ModelState.Values.SelectMany(e => e.Errors).ToList();
                erros.Clear();

                foreach (var error in modelErrors)
                    erros.Add(new Erro(string.Empty, error.ErrorMessage));

                context.ModelState.Clear();

                context.Result = new ObjectResult(null)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Value = erros
                };
            }
        }
    }
}
