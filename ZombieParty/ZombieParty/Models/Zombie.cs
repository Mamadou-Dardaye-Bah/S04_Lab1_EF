using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZombieParty.Models
{
    public class Zombie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        // FACULTATIF on peut formellement identifier le champ lien
        // sinon le champ de foreignKey sera auto généré dans la BD
        [Display(Name = "Zombie Type")]
        [ForeignKey("ZombieType")]
        [StringLength(20, MinimumLength = 5)]
        public int ZombieTypeId { get; set; }
        public ZombieType ZombieType { get; set; }
        [Range(1, 20)]
        public int Point { get; set; }
        [StringLength(255)]
        public string shortDesc { get; set; }
    }
}
