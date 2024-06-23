﻿using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class RepositorioInputModel
    {
        public RepositorioInputModel(int id)
        {
            this.id = id;
        }

        [DefaultValue("5757")]
        public int id { get; private set; }
    }
}
