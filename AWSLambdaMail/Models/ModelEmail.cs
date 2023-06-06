using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSLambdaMail.Models
{
    public class ModelEmail
    {
        public string Email { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
    }
}
