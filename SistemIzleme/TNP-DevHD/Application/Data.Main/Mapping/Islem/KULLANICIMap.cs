using Domain.Main.Models;
using Rota2.DataCore.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Main.Models.Mapping
{
    public class KullaniciMap : BaseMap<Kullanici>
    {
        public KullaniciMap()
        {
            // Properties
            //this.Property(t => t.ItemPath)
            //    .IsRequired()
            //    .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("KULLANICI");

            this.Property(t => t.KullaniciAdi).HasColumnName("KULLANICI_ADI");
        }
    }
}
