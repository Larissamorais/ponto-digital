using System;

namespace Ponto_Digital.Models
{
    public class ClienteModel
    {
        public int Id{get;set;}
        public string Nome {get;set;}
         public string Email {get;set;}
          public string Senha {get;set;}
          public string Tipo {get;set;}
          public DateTime DataCadastro{get;set;}
    }
    
    
}