﻿using Shared.Core.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class ClientNote: IEntity<int>, ISoftDelete, IAuditable, ICreate, IModify
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Note { get; set; }
        public bool ShowNote { get; set; }
        public DateTime? ModifiedDate { get; set; }     
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }

        #region Navigation Properties
        public virtual Client Client { get; set; }
        #endregion
    }
}
