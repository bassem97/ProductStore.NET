﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PorductStore.NET.Models;

namespace ClassLibrary1;

[Table("Product")]
public class Product : Concept
{

    public int ProductId{// set{ id = value; } get{ return id; }
        set;
        get;}
    [Display(Name ="Production Date")
     ,DataType(DataType.DateTime)]
    public DateTime DateProd {set; get;}
    [DataType(DataType.MultilineText)]
    public string Description {set; get;}

    [Required(ErrorMessage ="Label is required")]
    [MaxLength(50, ErrorMessage ="Maxlength 50")] 
    [StringLength(25, ErrorMessage = "Maxlength 25")] 
    public string Label {set; get;}
    [DataType(DataType.Currency)]
    [Range(0,int.MaxValue)]
    public double Price {set; get;}
    public int Quantity {set; get;}

    public string Image { get; set; }

    [ForeignKey("CategoryId")]
    public virtual Category category { set; get; }
    public int? CategoryId { get; set; }
    public IList<Provider> providers { set; get; }
    public IList<Bill> Bills { set; get; }
    public IList<Client> Clients { set; get; }

    public override string ToString()
    {
        return $"label= {Label}, description= {Description}, price= {Price}";
    }



    public void GetMyType()
    {
        Console.WriteLine("this is a product");
    }
    public override void GetDetails() // if sealed child classes can't inherit
    {
        System.Console.WriteLine("description: " + Description);

    }
}