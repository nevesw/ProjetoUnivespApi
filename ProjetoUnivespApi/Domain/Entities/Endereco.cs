﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoUnivespApi.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Cep { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Complemento { get; set; }
        public string? Pais { get; set; }
    }
}
