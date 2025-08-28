// id no line vayaj karavana cart nathi thata etale 48 thi 55 na baki se

import p1_img from '../assets/p1.jfif'
import p2_img from '../assets/p2.jfif'
import p3_img from '../assets/p3.avif'
import p4_img from '../assets/p4.jfif'
import p5_img from '../assets/2.webp'
import p6_img from '../assets/3.jfif'
import p7_img from '../assets/4.avif'
import p8_img from '../assets/5.avif'
import p9_img from '../assets/6.webp'
import p10_img from '../assets/7.jpg'
import p11_img from '../assets/8.avif'
import p12_img from '../assets/1.avif'
import p13_img from '../assets/women1.jfif'
import p14_img from '../assets/men1.webp'
import p15_img from '../assets/women2.jpg'
import p17_img from '../assets/men2.jpg'
import p18_img from '../assets/men3.webp'
import p19_img from '../assets/women3.jpg'
import p20_img from '../assets/men4.jfif'
import p22_img from '../assets/women4.webp'
import p24_img from '../assets/men5.webp'
import p26_img from '../assets/women5.webp'
import p28_img from '../assets/men6.webp'
import p30_img from '../assets/women6.webp'
import p32_img from '../assets/men7.jfif'
import p34_img from '../assets/women7.webp'
import p36_img from '../assets/men8.jpg'
import p16_img from '../assets/women8.jfif'

import p21_img from '../assets/kid1.jpg'
import p23_img from '../assets/kid2.jfif'
import p25_img from '../assets/kid3.jfif'
import p27_img from '../assets/kid4.webp'
import p29_img from '../assets/kid5.jfif'
import p31_img from '../assets/kid6.jfif'
import p33_img from '../assets/kid7.webp'
import p35_img from '../assets/kid8.jfif'
let all_product = [
     {
                id: 1,
                name: "Yellow Hakoba Dress",
                category: "women",
                image: p1_img,
                new_price: 500,
                old_price: 805
            },
        
            { id: 2, name: "Summer Outfits ", category: "women", image:p2_img, new_price: 600, old_price: 900 },
            { id: 3, name: "Kurti", category: "women", image:p3_img, new_price: 750, old_price: 1200 },
            { id: 4, name: "Yumi Kim Dress", category: "women", image: p4_img, new_price: 900, old_price: 1400 },
            { id: 5, name: "Dress", category: "women", image: p5_img, new_price: 450, old_price: 700 },
            { id: 6, name: "Hoodie", category: "men", image: p6_img, new_price: 850, old_price: 1300 },
            { id: 7, name: "Gym Outfit", category: "women", image: p7_img, new_price: 950, old_price: 1500 },
            { id: 8, name: "Shirt", category: "men", image: p8_img, new_price: 550, old_price: 1000 },
            { id: 9, name: "Leggings", category: "women", image: p9_img, new_price: 700, old_price: 1100 },
            { id: 10, name: "Sweater ", category: "men", image: p10_img, new_price: 880, old_price: 1350 },
            { id: 11, name: "Gown ", category: "women", image: p11_img, new_price: 920, old_price: 1450 },
            { id: 12, name: "T-Shirt ", category: "men", image: p12_img, new_price: 990, old_price: 1600 },
    {
        id: 13,
        name: "Kurti",
        category: "women",
        image: p13_img,
        new_price: 500,
        old_price: 805
    },

    { id: 14, name: "Shirt", category: "men", image:p14_img, new_price: 600, old_price: 905 },
    { id: 15, name: "Saree", category: "women", image:p15_img, new_price: 750, old_price: 1200 },
    { id: 17, name: "Shirt Pant", category: "men", image: p17_img, new_price: 900, old_price: 1400 },
    { id: 18, name: "Zels", category: "men", image: p18_img, new_price: 450, old_price: 700 },
    { id: 19, name: "Dress", category: "women", image: p19_img, new_price: 850, old_price: 1300 },
    { id: 20, name: "Treck Pant", category: "men", image: p20_img, new_price: 950, old_price: 1500 },
    { id: 22, name: "Sport Suit", category: "women", image: p22_img, new_price: 550, old_price: 1000 },
    { id: 24, name: "Jacket", category: "men", image: p24_img, new_price: 700, old_price: 1100 },
    { id: 26, name: "Jumpsuit", category: "women", image: p26_img, new_price: 880, old_price: 1350 },
    { id: 28, name: "professional Kurta", category: "men", image: p28_img, new_price: 920, old_price: 1450 },
    { id: 30, name: "Gown", category: "women", image: p30_img, new_price: 990, old_price: 1600 },
    { id: 32, name: "Sweater", category: "men", image: p32_img, new_price: 400, old_price: 650 },
    { id: 34, name: "Top", category: "women", image: p34_img, new_price: 520, old_price: 850 },
    { id: 36, name: "T-Shirt", category: "men", image: p36_img, new_price: 780, old_price: 1150 },
    { id: 16, name: "Skirt", category: "women", image:p16_img, new_price: 730, old_price: 1100 },
   

    { id: 21, name: "Denim Shirt", category: "kid", image: p21_img, new_price: 850, old_price: 1400 },
   
    { id: 23, name: "Cargo Pants", category: "kid", image:p23_img , new_price: 880, old_price: 1300 },
    
    { id: 25, name: "Trousers", category: "kid", image:p25_img , new_price: 760, old_price: 1200 },
    { id: 27, name: "Tank Top", category: "kid", image: p27_img, new_price: 490, old_price: 800 },
   
    { id: 29, name: "Formal Pants", category: "kid", image:p29_img, new_price: 980, old_price: 1600 },

    { id: 31, name: "Leather Jacket", category: "kid", image: p31_img, new_price: 1500, old_price: 2500 },

    { id: 33, name: "Gym Shorts", category: "kid", image: p33_img, new_price: 550, old_price: 900 },
  
    { id:35, name: "Casual Blazer", category: "kid", image: p35_img, new_price: 1050, old_price: 1700 },
    
]

export default all_product;