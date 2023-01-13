using System;
using System.Linq;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        var nbarang = new List<Barang>();
        var choice = 0;

        do
        {
            Console.WriteLine("1. Tambah Data");
            Console.WriteLine("2. Hapus Data");
            Console.WriteLine("3. Cari Data");
            Console.WriteLine("4. Tampilkan Data");
            Console.WriteLine("5. Keluar");
            Console.Write("Pilihan: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddData(nbarang);
                    break;
                case 2:
                    DeleteData(nbarang);
                    break;
                case 3:
                    SearchData(nbarang);
                    break;
                case 4:
                    DisplayData(nbarang);
                    break;
            }
        } while (choice != 5);
    }

    static void AddData(List<Barang> nbarang)
    {
        Console.WriteLine("ID Barang: ");
        var IDB = Console.ReadLine();
        Console.Write("Nama Barang: ");
        var name = Console.ReadLine();
        Console.Write("Jenis Barang: ");
        var jenis = Console.ReadLine();
        Console.Write("Harga Barang: ");
        var harga = Console.ReadLine();

        nbarang.Add(new Barang { IDB = IDB, Name = name, Jenis = jenis, Harga = harga });
        Console.WriteLine("Data berhasil ditambahkan!");
    }

    static void DeleteData(List<Barang> nbarang)
    {
        Console.Write("Masukkan ID Barang yang akan dihapus: ");
        var idb = Console.ReadLine();

        var barang = nbarang.SingleOrDefault(s => s.IDB == idb);
        if (barang != null)
        {
            nbarang.Remove(barang);
            Console.WriteLine("Data berhasil dihapus!");
        }
        else
        {
            Console.WriteLine("Data tidak ditemukan!");
        }
    }

    static void SearchData(List<Barang> nbarang)
    {
        Console.Write("Masukkan ID Barang yang akan dicari: ");
        var jenis = Console.ReadLine();

        var barang = nbarang.SingleOrDefault(s => s.Jenis == jenis);
        if (barang != null)
        {
            Console.WriteLine("+-----------+-------------+--------------+---------+");
            Console.WriteLine("| ID Barang | Nama Barang | Jenis Barang |  Harga  |");
            Console.WriteLine("+-----------+-------------+--------------+---------+");
            Console.WriteLine("| {0,-11} | {1,-13} | {2,-20} |", barang.IDB, barang.Name, barang.Jenis, barang.Harga);
            Console.WriteLine("+-----------+-------------+--------------+---------+");
        }
        else
        {
            Console.WriteLine("Data tidak ditemukan!");
        }
    }
    static void DisplayData(List<Barang> nbarang)
    {
        int n;
        int[] data = new int[n];
        Console.WriteLine("Pilih metode sorting: ");
        Console.WriteLine("1. ID Barang");
        var sorting = int.Parse(Console.ReadLine());

        if (sorting == 1)
            for (int i = 0; i < n; i++)
            {
                Console.Write(data[i] + " "); // Menampilkan data ke-i
            }
        for (int i = 0; i < n - 1; i++)
        {
            int min_idx = i; // Inisialisasi indeks data terkecil sebagai i
            for (int j = i + 1; j < n; j++)
                if (data[j] < data[min_idx]) // Jika data ke-j lebih kecil dari data terkecil yang sudah ditentukan sebelumnya
                    min_idx = j; // Update indeks data terkecil menjadi j
            int temp = data[min_idx]; // Simpan data terkecil dalam variabel temp
            data[min_idx] = data[i]; // Tukar posisi data terkecil dengan data ke-i
            data[i] = temp; // Tukar posisi data ke-i dengan data yang tersimpan dalam temp
        }
        Console.WriteLine("+-----------+-------------+--------------+---------+");
        Console.WriteLine("| ID Barang | Nama Barang | Jenis Barang |  Harga  |");
        Console.WriteLine("+-----------+-------------+--------------+---------+");
        foreach (var barang in nbarang)
        {
            Console.WriteLine("| {0,-11} | {1,-13} | {2,-20} |", barang.IDB, barang.Name, barang.Jenis, barang.Harga);
        }
        Console.WriteLine("+-----------+-------------+--------------+---------+");
    }
}

class Barang
{
    public string IDB { get; set; }
    public string Name { get; set; }
    public string Jenis { get; set; }
    public string Harga { get; set; }
}
/* 2. Saya menggunakan algoritma selection sort untuk mengurutkan datanya.
3. Perbedaan array dan linked list :
   * Di setiap elemen array hanya berisi data saja. Sedangkan setiap elemen linked list terdiri dari 2 bagian, data dan pointer address.
   * Dalam array pengalokasian ruang memori terbatas pada jumlah ruang yang dideklarasikan sebelumnya. Sedangkan 
     dalam linked list pengalokasian ruang memori dilakukan tanpa pendeklarasian sebelumnya dan terbatas pada jumlah ruang memori yang tersisa (dapat dipakai).
   * Kebutuhan memory dalam array lebih sedikit dibandingkan dengan linked list.
   * Tipe data dalam array statis. Sedangkan dalam linked list dinamis.
4. Algoritma Queue merupakan struktur data dimana satu data dapat ditambakan diakhir
   disebut rear dan data dihapus dari yang paling terkahir disebut front.
5. a. * Node 41 dengan 74 
      * Node 16 dengan 53
      * Node 46 dengan 55
      * Node 63 dengan 70
      * Node 62 dengan 64
   b. Pre-order dilakukan mulai dari akar pohon, dengan urutan:
      1. Cetak isi (data) node yang sedang dikunjungi
      2. Kunjungi kiri node tersebut,
         - Jika kiri bukan kosong (tidak NULL) mulai lagi dari langkah pertama, terapkan untuk kiri ttruktur data tersebut.
         - Jika kiri kosong (NULL), lanjut ke langkah ketiga.
      3. Kunjungi kanan node tersebut,
         - Jika kanan bukan kosong (tidak NULL) mulai lagi dari langkah pertama, terapkan untuk kanan tersebut.
         - Jika kanan kosong (NULL), proses untuk node ini selesai, tuntaskan proses yang sama untuk node yang dikunjungi sebelumnya.*/