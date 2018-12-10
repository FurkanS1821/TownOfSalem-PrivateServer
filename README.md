# Town of Salem Private Server

## What is this?

A private server for you and your friends to play Town of Salem on.

## How can I use it?

1. Compile the server.

2. **Create an RSA key.**

- a: Store the private key you have created in a `.pem` file called `Private Key.pem` under the executing directory.
- b: Backup the file `Town of Salem/Login_{version_number}.swf` somewhere in case you want to play on live servers.
- c: Open the file `Town of Salem/Login_{version_number}.swf` with an `.swf` editor ([JPEXS Flash Decompiler](https://www.free-decompiler.com/flash/) is recommended.)
- d: In the file `./salem/utils/crypto/CryptUtils`, change the `_pem` variable with the **public** key you've created.
- e: Save the file.

3. Either add a redirect to the real Town of Salem or change the address of the server in the `.swf` files one by one.
- **3.1: Easier method:**
- Open the file `C:\Windows\System32\drivers\etc\hosts` as administrator with any text editor (you need admin privileges to save it)
- Add the line `127.0.0.1 live4.tos.blankmediagames.com` (replace the IP address with the IP given to you if server is on a remote computer)

- **3.2: Harder method:**
- Use the way described in step 2 to edit a few `.swf` files. This time, you will open `Town of Salem/Home_{version_number}.swf`, `Login_{version_number}.swf`, and `TownOfSalem_{version_number}.swf` files and change the field `m_sRealIP` in the files `salem/sharedinfo/SharedInfo`.

4. Run the server and go into the game!

## To get back on the live servers:

- Replace the .swf files you have edited with their originals.
- If you have edited the `hosts` file, open it and add a `#` in front of the line with which you'd customized the server address. (`#` is for easier switching, you can as well delete that line if you will not use private server again.)

## Disclaimer

This code is licensed under GNU Affero General Public License 3.0.

This code was written for educational purposes only.

I, the writer of this code, cannot be kept responsible for damages caused by usage of this code for things including, but not limited to, somehow exploting Steam achievements or using this code on a public server for password phishing.
