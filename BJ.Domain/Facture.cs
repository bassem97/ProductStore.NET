using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BJ.Domain
{
    public class Facture
    {
        public float Prix { get; set; }
        public DateTime DateAchat { get; set; }

        public virtual Client Client { get; set; }
       // [ForeignKey("Client")]
        public int ClientFK { get; set; }
        
        public virtual Product Product { get; set; }
       // [ForeignKey("Product")]
        public int ProductFK { get; set; }
    }
}
