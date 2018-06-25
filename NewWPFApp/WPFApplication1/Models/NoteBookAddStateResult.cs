using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApplication1.Models;

namespace WPFApplication1.Models
{
    //Модель ответа от сервера, когда он содержит массив объектов "Состояние"
    public class NoteBookAddStateResult
    {
        public String Add { get; set; }
    }
}
