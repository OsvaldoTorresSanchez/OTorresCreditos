using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Credito
    {

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.OTorresCreditosContainer context = new DL.OTorresCreditosContainer())
                {
                    var resultQuery = context.CreditoGetAll().ToList();

                    if (resultQuery != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in resultQuery)
                        {
                            ML.Credito credito = new ML.Credito();

                            credito.NumeroCredito = obj.NumeroCredito;
                            credito.ImporteCredito = (decimal)obj.ImporteCredito;
                            credito.PLazo = (int)obj.Plazo;
                            credito.TasaAnual = (decimal)obj.TasaAnual;


                            result.Objects.Add(credito);
                            result.Correct = true;
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error la tabla no contiene informacion ";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }



    }
}
