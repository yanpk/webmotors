using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebMotors.Model;

namespace WebMotors.Repository.Map
{
    internal partial class AnuncioWebMotorsMap : IEntityTypeConfiguration<AnuncioWebMotors>
    {
        public AnuncioWebMotorsMap()
        {
        }

        public void Configure(EntityTypeBuilder<AnuncioWebMotors> builder)
        {
            builder.ToTable("tb_AnuncioWebmotors", "dbo");
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.Marca).HasMaxLength(45).IsRequired();
            builder.Property(t => t.Modelo).HasMaxLength(45).IsRequired();
            builder.Property(t => t.Versao).HasMaxLength(45).IsRequired();
            builder.Property(t => t.Ano).IsRequired();
            builder.Property(t => t.Quilometragem).IsRequired();
            builder.Property(t => t.Observacao).HasMaxLength(1000).IsRequired();
        }
    }
}
