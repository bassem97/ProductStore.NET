﻿namespace ClassLibrary1;

public class Provider : Concept
{
    public static int Id { set; get; }
    public string UserName { get; set; }
    private string password;
    
    private string confirmPassword;
    private string email;
    private bool isAprooved;
    
    public Provider()
    {
        Id++;
    }

    public Provider(string userName, string password, string confirmPassword, string email)
    {
        this.UserName = userName;
        this.password = password;
        this.confirmPassword = confirmPassword;
        this.email = email;
        Id++;
    }
    
    public string Password
    {
        get => password;
        set
        {
            if (value.Length is < 5 or > 20)
            {
                System.Console.WriteLine("Password length must be 5..20");
            }
            else
            {
                password = value;
            }
        }
    }

    public string ConfirmPassword
    {
        get => confirmPassword;
        set
        {
            if (value == password)
            {
                confirmPassword = value;
            }
            else
            {
                System.Console.WriteLine("Password must be identical");
            }
        }
    }

    public string Email
    {
        get => email;
        set => email = value ?? throw new ArgumentNullException(nameof(value));
    }

    public bool IsAprooved
    {
        get => isAprooved;
        set => isAprooved = value;
    }
    
    public override string ToString()
    {
        return $"{{ ID: {Id}, Name: {UserName}, Email: {Email}, isApproved: {IsAprooved}  }}";
    }
    
    public bool Login(string? userName, string? password, string? email = null)
    {
        return email != null
            ? userName == UserName && password == Password && email == Email
            : userName == UserName && password == Password;

    }
    
    public static void SetIsApproved(Provider provider,out bool? isApproved){
        provider.isAprooved = provider.Password == provider.confirmPassword;
        isApproved = provider.isAprooved;
    }
    public static void SetIsApproved(string? confirmPassword, string? password, out bool? isApproved)
    {
        isApproved = password == confirmPassword;
    }
    
     
    public override void GetDetails()
    {
        Console.WriteLine("Les details de l'entité provider");
    }
    
    public GetProducts(string filterType, string filterValue)
   
}

