using Dominio.Core.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace WepsysChallengeAPI
{
    public class ErrorModelState
    {
        public static Error catchError(ModelStateDictionary ModelState)
        {
            var errors = new List<string>();
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
            return new Error { errores = errors };
        }

        public static Error catchError(string error)
        {
            var errors = new List<string>();
            errors.Add(error);
            return new Error { errores = errors };
        }
    }
}
