using Rota2.DataCore.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Main.Models;

namespace Data.Main.Models.Mapping
{
    public class MessageLogMap : BaseMap<MessageLog>
    {
        public MessageLogMap()
        {
            this.Property(t => t.IslemAdi)
                .HasMaxLength(250);
            this.Property(t => t.Id).IsRequired();

            this.ToTable("MESSAGE_LOG");

            this.Property(t => t.KullaniciId).HasColumnName("KULLANICI_ID");

            this.Property(t => t.IslemAdi).HasColumnName("ISLEM_ADI");

            this.Property(t => t.RequestMessageDate).HasColumnName("REQUEST_MESSAGE_DATE");

            this.Property(t => t.ResponseMessageDate).HasColumnName("RESPONSE_MESSAGE_DATE");

            this.Property(t => t.ResponseStatusId).HasColumnName("RESPONSE_STATUS_ID");

            this.Property(t=>t.OlusturulmaTarihi).HasColumnName("OLUSTURULMA_TARIHI");

        }
    }
}
