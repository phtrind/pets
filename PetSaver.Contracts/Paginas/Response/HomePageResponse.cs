﻿using PetSaver.Contracts.Anuncios;
using PetSaver.Contracts.Base;
using System.Collections.Generic;

namespace PetSaver.Contracts.Paginas
{
    public class HomePageResponse : BasePageContract
    {
        public IEnumerable<AnuncioMiniaturaResponse> Anuncios { get; set; }
        public FiltroAnuncioResponse Filtros { get; set; }
    }
}
