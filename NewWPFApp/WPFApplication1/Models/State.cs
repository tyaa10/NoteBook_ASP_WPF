using Catel.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApplication1.Models
{
    public class State : ModelBase
    {
        [Required]
        public int Id
        {
            get { return GetValue<int>(idProperty); }
            set { SetValue(idProperty, value); }
        }

        public static readonly PropertyData idProperty = RegisterProperty(nameof(Id), typeof(int), null);

        [Required]
        public string Name
        {
            get { return GetValue<string>(nameProperty); }
            set { SetValue(nameProperty, value); }
        }

        public static readonly PropertyData nameProperty = RegisterProperty(nameof(Name), typeof(string), null);
    }
}
