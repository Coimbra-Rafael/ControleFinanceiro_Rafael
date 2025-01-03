using System;

namespace ControleFinanceiro.WinForm.Models.Base
{
    public abstract class BaseEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }

        protected BaseEntity()
        {
            CreatedOn = DateTime.Now;
            UpdateOn = DateTime.Now;
        }

        protected BaseEntity(DateTime createdOn)
        {
            CreatedOn = createdOn;
            UpdateOn = DateTime.Now;
        }
    }
}
