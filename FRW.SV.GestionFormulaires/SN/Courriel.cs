﻿using FRW.TR.Commun;
using SV.GestionFormulaires.SN;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FRW.SV.GestionFormulaires.SN
{
    public class Courriel
    {
        public async Task Envoyer()
        {
            //TODO Envoyer le courriel

            //TODO mettre le bon numéro
            await SuiviEtat.Creer("", Constantes.EtatCourriel);

            throw new NotImplementedException();
        }
    }
}