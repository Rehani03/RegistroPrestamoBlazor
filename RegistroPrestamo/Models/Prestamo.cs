﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPrestamo.Models
{
    public class Prestamo
    {
        [Key]
        [Required(ErrorMessage = "El campo Id no puede estar vacío.")]
        [Range(0, 1000000, ErrorMessage = "El campo Id no puede ser menor que cero o mayor a 1000000.")]
        public int prestamoId { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime fecha { get; set; }

        public int personaId { get; set; }

        [Required(ErrorMessage = "El campo concepto no puede estar vacía.")]
        [MinLength(5, ErrorMessage = "El concepto es muy corta.")]
        [MaxLength(40, ErrorMessage = "El concepto debe contener menos de 60 caracteres.")]
        public string concepto { get; set; }
        
        public decimal monto { get; set; }
        [Required(ErrorMessage = "El campo balance no puede estar vacio.")]
        public decimal balance { get; set; }

        public Prestamo()
        {
            prestamoId = 0;
            fecha = DateTime.Now;
            personaId = 0;
            concepto = string.Empty;
            monto = 0;
            balance = 0;
        }
    }
}
