using Amazon.Lambda.Core;
using AWSLambdaMail.Helpers;
using AWSLambdaMail.Models;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer
    (typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambdaMail;

public class Function
{
    
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<string> 
        FunctionHandler(ModelEmail model, ILambdaContext context)
    {
        HelperMail helper = new HelperMail();
        await helper.SendMailAsync(model.Email, model.Asunto
            , model.Cuerpo);
        var response = new
        {
            Email = model.Email,
            Asunto = model.Asunto,
            Mensaje = "Email enviado correctamente"
        };
        string dataJson = JsonConvert.SerializeObject(response);
        return dataJson;
    }
}
