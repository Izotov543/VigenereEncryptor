# VigenereEncryptor
Test task solution

1. Реализовать систему шифрования методом Винжера:
Сигнатура метода шифрования:
string Encrypt(string source, string key);

Сигнатура метода расшифрования:
string Decrypt(string encrypted, string key);

Плюсом будет, если кандидат реализует сигнатуры:
Сигнатура метода шифрования:
IEnumerable<string> Encrypt(IEnumerable<string>source, string key);

Сигнатура метода расшифрования:
IEnumerable<string> Decrypt(IEnumerable<string> encrypted, string key);
