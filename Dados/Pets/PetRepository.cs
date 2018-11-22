using PetSaver.Entity.Enums.Pets;
using PetSaver.Entity.Pets;
using PetSaver.Exceptions;
using System;

namespace PetSaver.Repository.Pets
{
    public class PetRepository : BaseRepository<PetEntity>
    {
        protected override void ValidarAtributos(PetEntity aObjeto)
        {
            if (aObjeto.IdAnimal == default || new AnimalRepository().Listar(aObjeto.IdAnimal) == null)
            {
                throw new DbValidationException("O Id do animal é inválido.");
            }

            if (string.IsNullOrEmpty(aObjeto.Nome))
            {
                aObjeto.Nome = null;
            }

            if (aObjeto.IdRacaEspecie.HasValue)
            {
                if (aObjeto.IdRacaEspecie.Value == default)
                {
                    aObjeto.IdRacaEspecie = null;
                }
                else
                {
                    var raca = new RacaEspecieRepository().Listar(aObjeto.IdRacaEspecie.Value);

                    if (raca == null)
                    {
                        throw new DbValidationException("O Id da raça é inválido.");
                    }

                    if (raca.IdAnimal != aObjeto.IdAnimal)
                    {
                        throw new BusinessException("O Id da raça não é referente ao Id do animal.");
                    }
                }
            }

            if (aObjeto.IdSexo.HasValue)
            {
                if (aObjeto.IdSexo.Value == default)
                {
                    aObjeto.IdSexo = null;
                }
                else if (!Enum.IsDefined(typeof(Sexos), aObjeto.IdSexo))
                {
                    throw new DbValidationException("O Id do sexo do pet é inválido.");
                }
            }

            if (aObjeto.IdIdade.HasValue)
            {
                if (aObjeto.IdIdade.Value == default)
                {
                    aObjeto.IdIdade = null;
                }
                else if (!Enum.IsDefined(typeof(Idades), aObjeto.IdIdade))
                {
                    throw new DbValidationException("O Id da idade do pet é inválido.");
                }
            }

            if (aObjeto.IdPorte != default && !Enum.IsDefined(typeof(Portes), aObjeto.IdPorte))
            {
                throw new DbValidationException("O Id do porte do pet é inválido.");
            }

            if (aObjeto.IdPelo.HasValue)
            {
                if (aObjeto.IdPelo.Value == default)
                {
                    aObjeto.IdPelo = null;
                }
                else if (!Enum.IsDefined(typeof(Pelos), aObjeto.IdPelo))
                {
                    throw new DbValidationException("O Id do pelo do pet é inválido.");
                }
            }

            var corRepository = new CorRepository();

            if (aObjeto.IdCorPrimaria == default || corRepository.Listar(aObjeto.IdCorPrimaria) == null)
            {
                throw new DbValidationException("O Id da cor primária do pet é inválido.");
            }

            if (aObjeto.IdCorSecundaria.HasValue)
            {
                if (aObjeto.IdCorSecundaria.Value == aObjeto.IdCorPrimaria)
                {
                    throw new BusinessException("A cor primária não pode ser igual à cor secundária.");
                }

                if (aObjeto.IdCorSecundaria.Value == default)
                {
                    aObjeto.IdCorSecundaria = null;
                }
                else if (corRepository.Listar(aObjeto.IdCorSecundaria.Value) == null)
                {
                    throw new DbValidationException("O Id da cor secundária do pet é inválido.");
                }
            }
        }
    }
}
