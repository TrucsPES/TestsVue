﻿using ECS.TR.Contrats;
using Microsoft.AspNetCore.Mvc;
using SV.GestionFormulaires.SN;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FRW.SV.GestionFormulaires.Controller
{
    [Route("/api/v1/[controller]/[action]")]
    [ApiController]
    public class FormulairesController: ControllerBase
    {
        private readonly CreerFormulaireAF _creerFormulaire;
        private readonly MajFormulaireAF _majFormulaire;
        private readonly ObtenirConfiguration _obtenirConfig;

        public FormulairesController(CreerFormulaireAF creer, MajFormulaireAF maj)
        {
            _creerFormulaire = creer;
            _majFormulaire = maj;
        }

        [HttpGet]
        public async Task<ActionResult<AppelSortant<string>>> ObtenirConfigurationFormulaire(string nomForm)
        {
            var a = await _obtenirConfig.ObtenirFichierConfig(nomForm);
            return Ok(a);
        }

        [HttpGet]
        public async Task<ActionResult<AppelSortant<string>>> ObtenirBindingFormulaire(string nomForm)
        {
            var a = await _obtenirConfig.ObtenirFichierBinding(nomForm);
            return Ok(a);
        }

        [HttpPost]
        public async Task<ActionResult<AppelSortant<string>>> CreerFormulaire(string nomForm)
        {
            // Todo obtenir le idSys dans l'url de la requête ou le fichier de config
            var a = await _creerFormulaire.Traitement(nomForm, "IdSys", null);
            return Ok(a);
        }

        [HttpPost]
        public async Task<ActionResult<AppelSortant<string>>> MajFormulaire(string noSeqForm)
        {
            //TODO vérifier le cookie pour déterminer si on envoie le courriel
            bool envoyerCourriel = true;
            var a = await (_majFormulaire.Traitement(noSeqForm, null, envoyerCourriel));
            return Ok(a);
        }

    }
}