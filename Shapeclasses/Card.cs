using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapeclasses
{
    [Table("Card")]
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public double Top { get; set; }
        public double Left { get; set; }

    }
}
