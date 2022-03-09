using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVC.Models
{
    public class Page3ViewModel
    {
        public DateTime m_now => DateTime.Now;
        public string m_str1;
        [BindProperty]
        public string? m_input1 { get; set; }
    }
}