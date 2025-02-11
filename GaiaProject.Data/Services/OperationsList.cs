using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Data.Services
{
    public class OperationsList
    {
        public string GetResult(string oper, string field1, string field2)
        {
            switch (oper)
            {
                case "Add":
                    try
                    {
                        decimal num = decimal.Parse(field1.ToString()) + decimal.Parse(field2.ToString());
                        return num.ToString();
                    }
                    catch (ArgumentException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    break;
                case "Subtract":
                    try
                    {
                        decimal num1 = decimal.Parse(field1.ToString());
                        decimal num2 = decimal.Parse(field2.ToString());
                        return (num1 - num2).ToString();
                    }
                    catch (ArgumentException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    break;
                case "Multiply":
                    try
                    {
                        return (Convert.ToDecimal(field1) * Convert.ToDecimal(field2)).ToString();
                    }
                    catch(ArgumentException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    break;
                case "Divide":
                    try
                    {
                        return (Convert.ToDecimal(field1) / Convert.ToDecimal(field2)).ToString();
                    }
                    catch (ArgumentException ex)
                    {
                        throw new Exception(ex.Message);
                    }catch(DivideByZeroException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    break;
                case "Concat":
                    try
                    {
                        return field1+" "+field2;
                    }
                    catch (ArgumentException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    break;
                default:
                    throw new Exception("Invalid operation type");
            }

        }
    }
}
