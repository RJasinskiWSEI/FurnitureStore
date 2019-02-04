using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStore.Infrastructure.Services.FurnitureItems
{
    public class FurnitureItemsService : IFurnitureItemsService
    {
        private readonly Dictionary<int, FurnitureItem> _furnitureItems = new Dictionary<int, FurnitureItem>
        {
            { 1, new FurnitureItem
                {
                    Id = 1,
                    Category = FurnitureCategory.Corners,
                    Name = "BRAVO NAROŻNIK 3w-1ot z funkcją spania w skórach s1",
                    Description = "NAROŻNIK ( SEGM. 3W L/1130W + SEGM. 1ot P/5210)) z kolekcji Bravo i w grupie materiałowej A1. Możliwość zamówienia w innej grupie tkaninowej- cena zależna od grupy tkaninowej. Kolekcja BRAVO to pomysł jak pośród codziennego pośpiechu wprowadzić do domu odrobinę przytulnej, leniwej atmosfery i odprężającego relaksu.",
                    Price = 6827.00m,
                    ImageUrl = @"https://szczawnicka.pl/images/WAJNERT/mini/350px_Bravo%20naroznik%203w%201ot.jpg"
                }
            },
            { 2, new FurnitureItem
                {
                    Id = 2,
                    Category = FurnitureCategory.Corners,
                    Name = "BRAVO NAROŻNIK 3w-1ot z funkcją spania w skórach s1",
                    Description = "NAROŻNIK ( SEGM. 3W L/1130W + SEGM. 1ot P/5210)) z kolekcji Bravo i w grupie materiałowej A1. Możliwość zamówienia w innej grupie tkaninowej- cena zależna od grupy tkaninowej. Kolekcja BRAVO to pomysł jak pośród codziennego pośpiechu wprowadzić do domu odrobinę przytulnej, leniwej atmosfery i odprężającego relaksu.",
                    Price = 6827.00m,
                    ImageUrl = @"https://szczawnicka.pl/images/WAJNERT/mini/350px_Bravo%20naroznik%203w%201ot.jpg"
                }
            },
            { 3, new FurnitureItem
                {
                    Id = 3,
                    Category = FurnitureCategory.Corners,
                    Name = "BRAVO NAROŻNIK 3w-1ot z funkcją spania w skórach s1",
                    Description = "NAROŻNIK ( SEGM. 3W L/1130W + SEGM. 1ot P/5210)) z kolekcji Bravo i w grupie materiałowej A1. Możliwość zamówienia w innej grupie tkaninowej- cena zależna od grupy tkaninowej. Kolekcja BRAVO to pomysł jak pośród codziennego pośpiechu wprowadzić do domu odrobinę przytulnej, leniwej atmosfery i odprężającego relaksu.",
                    Price = 6827.00m,
                    ImageUrl = @"https://szczawnicka.pl/images/WAJNERT/mini/350px_Bravo%20naroznik%203w%201ot.jpg"
                }
            },
            { 4, new FurnitureItem
                {
                    Id = 4,
                    Category = FurnitureCategory.Beds,
                    Name = "Łóżko Yoop YPL 09",
                    Description = "Młodzieżowe łóżko z kolekcji Yoop.",
                    Price = 365.00m,
                    ImageUrl = @"https://szczawnicka.pl/images/FORTE/YOOP/mini/350px_Lozko_YPL09.jpg"
                }
            },
        };

        // In real App downloaded by REST Request or direct DB connection (not recommended in my opinion)
        public Task<IEnumerable<FurnitureItem>> GetFurnitureItems(FurnitureCategory category)
        {
            var categoryItems = _furnitureItems.Where(x => x.Value.Category == category).Select(x => x.Value);

            return Task.FromResult(categoryItems);
        }
    }
}
