﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Business.Services
{
    public class Notificacao
    {
        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; }
    }
}