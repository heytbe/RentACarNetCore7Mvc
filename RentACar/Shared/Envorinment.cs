namespace RentACar.Shared
{
    public static class Envorinment
    {
        public static IWebHostEnvironment webHost { get; set; }

        public static void Initial(IWebHostEnvironment webHostEnvironment)
        {
            webHost = webHostEnvironment;
        }
    }
}
