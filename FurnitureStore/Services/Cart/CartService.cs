using FurnitureStore.Models;
using IronPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureStore.Services.Cart
{
    public class CartService : ICartService
    {
        private readonly List<CartItem> _cartItems;

        public CartService()
        {
            _cartItems = new List<CartItem>();
        }

        #region ICartService Implementation

        public IReadOnlyList<CartItem> GetCartItems()
        {
            return (new List<CartItem>(_cartItems)).AsReadOnly();
        }

        public void AddItem(FurnitureItem item)
        {
            var cartItem = FindByFurnitureItem(item);

            if (cartItem != null)
            {
                cartItem.Count++;
            }
            else
            {
                _cartItems.Add(new CartItem { Item = item });
            }
        }

        public void RemoveItem(FurnitureItem item)
        {
            var cartItem = FindByFurnitureItem(item);

            if (cartItem != null)
            {
                _cartItems.Remove(cartItem);
            }
        }

        public decimal GetTotalCost()
        {
            return _cartItems.Sum(x => x.Count * x.Item.Price);
        }

        public void ClearCart()
        {
            _cartItems.Clear();
        }

        public bool Checkout()
        {
            var htmlToPdf = new HtmlToPdf();
            var invoiceBuilder = new StringBuilder();

            // header
            invoiceBuilder.AppendLine("<table style=\"margin - left: auto; margin - right: auto; \">");
            invoiceBuilder.AppendLine("<thead>");
            invoiceBuilder.AppendLine("<tr>");
            invoiceBuilder.AppendLine("<th>Lp.</th>");
            invoiceBuilder.AppendLine("<th>Furniture name</th>");
            invoiceBuilder.AppendLine("<th>Quantity</th>");
            invoiceBuilder.AppendLine("<th>Price [PLN]</th>");
            invoiceBuilder.AppendLine("</tr>");
            invoiceBuilder.AppendLine("</thead>");

            // positions
            invoiceBuilder.AppendLine("<tbody>");
            int counter = 0;
            foreach (var cartItem in _cartItems)
            {
                invoiceBuilder.AppendLine("<tr>");
                invoiceBuilder.AppendLine($"<td>{++counter}</td>");
                invoiceBuilder.AppendLine($"<td>{cartItem.Item.Name}</td>");
                invoiceBuilder.AppendLine($"<td>{cartItem.Count}</td>");
                invoiceBuilder.AppendLine("<td>");

                var itemsPrice = cartItem.Item.Price * cartItem.Count;
                invoiceBuilder.AppendLine($"<p>{itemsPrice}</p>");

                invoiceBuilder.AppendLine("</td>");
                invoiceBuilder.AppendLine("</tr>");
            }
            invoiceBuilder.AppendLine("</tbody>");
            invoiceBuilder.AppendLine("</table>");
            
            var pdfResource = htmlToPdf.RenderHtmlAsPdf(invoiceBuilder.ToString());
            pdfResource.SaveAs($"Checkout.pdf");

            return true;
        }

        #endregion

        private CartItem FindByFurnitureItem(FurnitureItem item)
        {
            var furnitureItem = _cartItems.FirstOrDefault(x => x.Item.Equals(item));

            return furnitureItem;
        }
    }
}
