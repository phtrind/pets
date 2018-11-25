using System;
using System.Collections.Generic;
using PetSaver.Contracts.Anuncios;
using PetSaver.Contracts.Base;
using PetSaver.Contracts.Pets;
using PetSaver.Entity.Pets;
using PetSaver.Exceptions;
using PetSaver.Repository.Pets;

namespace PetSaver.Business.Pets
{
    public class PetBusiness : BaseBusiness<PetEntity, PetRepository>
    {
        public int Cadastrar(int aIdLogin, CadastroPetContract aRequest)
        {
            if (aRequest == null)
            {
                throw new BusinessException("O objeto do Pet não pode ser nulo.");
            }

            return Inserir(new PetEntity()
            {
                IdLoginCadastro = aIdLogin,
                IdAnimal = aRequest.IdAnimal,
                IdRacaEspecie = aRequest.IdRacaEspecie,
                IdSexo = aRequest.IdSexo,
                IdIdade = aRequest.IdIdade,
                IdPorte = aRequest.IdPorte,
                IdPelo = aRequest.IdPelo,
                IdCorPrimaria = aRequest.IdCorPrimaria,
                IdCorSecundaria = aRequest.IdCorSecundaria,
                Nome = aRequest.Nome,
                Peso = aRequest.Peso,
                Vacinado = aRequest.Vacinado,
                Vermifugado = aRequest.Vermifugado,
                Castrado = aRequest.Castrado,
                Descricao = aRequest.Descricao
            });
        }

        public FiltrosPorAnimalResponse BuscarFiltrosPorAnimal(int aIdAnimal)
        {
            return new FiltrosPorAnimalResponse()
            {
                Sexos = new SexoBusiness().Combo(),
                RacasEspecies = new RacaEspecieBusiness().BuscarPorAnimal(aIdAnimal),
                Pelos = new PeloBusiness().Combo(),
                Idades = new IdadeBusiness().Combo(),
                Cores = new CorBusiness().Combo(),
                Portes = new PorteBusiness().Combo()
            };
        }
    }
}
