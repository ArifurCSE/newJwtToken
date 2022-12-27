using System.Collections.Generic;

namespace JwtToken.Models
{
    public class GovtInfoAPIViewModel
    {
        public GovtInfoAPIViewModel()
        {
            file = new FileViewModel();
        }
        public string fileType { get; set; }
        public string maininscl { get; set; }
        public bool importDup { get; set; }
        public bool assignToMe { get; set; }
        public bool opRefer { get; set; }
        public List<string> dataTypes { get; set; }
        public FileViewModel file { get; set; }

    }
    public class FileViewModel
    {
        public FileViewModel()
        {
            ins = new Blob();
            pat = new Blob();
            opd = new Blob();
            orf = new Blob();
            odx = new Blob();
            oop = new Blob();
            ipd = new Blob();
            irf = new Blob();
            idx = new Blob();
            iop = new Blob();
            cht = new Blob();
            cha = new Blob();
            aer = new Blob();
            adp = new Blob();
            lvd = new Blob();
            dru = new Blob();
        }
        public Blob ins { get; set; }
        public Blob pat { get; set; }
        public Blob opd { get; set; }
        public Blob orf { get; set; }
        public Blob odx { get; set; }
        public Blob oop { get; set; }
        public Blob ipd { get; set; }
        public Blob irf { get; set; }
        public Blob idx { get; set; }
        public Blob iop { get; set; }
        public Blob cht { get; set; }
        public Blob cha { get; set; }
        public Blob aer { get; set; }
        public Blob adp { get; set; }
        public Blob lvd { get; set; }
        public Blob dru { get; set; }
        public string lab { get; set; }
    }
    public class Blob
    {
        public string blobName { get; set; }
        public string blobType { get; set; }
        public string blob { get; set; }
        public string encoding { get; set; }
        public int size { get; set; }
    }
}
