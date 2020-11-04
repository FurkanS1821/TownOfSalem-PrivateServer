# Town of Salem Private Server

## What is this?

A private server for you and your friends to play Town of Salem on.

## How can I use it?

Before we begin telling you *how*, let's say a few words.

**This project is still under development, and in the very early stages of it, thus, there is no playable game at the moment.**

The tutorial below is quite hard for the newbie, and because of the reason stated above, I will not help anyone with it, at least until there is a somewhat playable game. If you can't complete this, you're probably not a programmer, and you had better come back later.

**ANY ISSUES CREATED ABOUT HELP WITH THIS TUTORIAL** (exceptions are if you are a *real* programmer and want to help) **WILL BE DELETED.**

1. Compile the server.

2. **Create an RSA key.**

- a: Store the private key you have created in a `.pem` file called `Private Key.pem` under the executing directory.
- b: Backup the file `Town of Salem\TownOfSalem_Data\Managed\Assembly-CSharp.dll` somewhere in case you want to play on live servers.
- c: Open the file `Town of Salem\TownOfSalem_Data\Managed\Assembly-CSharp.dll` using [dnSpy](https://github.com/dnSpy/dnSpy).
- d: In root directory, find `Crypto.cs` and inside it, change the `publicKey` field with your **public** key. (Make sure it's one line)
- e: Save the `.dll` file.

3. Either add a redirect to the real Town of Salem or change the address of the server in the game files.
- **3.1: Easier method:**
- Open the file `C:\Windows\System32\drivers\etc\hosts` as administrator with any text editor (you need admin privileges to save it)
- Add the line `127.0.0.1 live4.tos.blankmediagames.com` (replace the IP address with the IP given to you if server is on a remote computer)

- **3.2: Harder method:**
- TODO


4. Run the server and go into the game.

## To get back on the live servers:

- Replace the .dll file you have edited with their originals.
- If you have edited the `hosts` file, open it and add a `#` in front of the line with which you'd redirected the server address. (`#` is for easier switching, you can as well delete that line if you will not use private server again.)

## Disclaimer

This code is licensed under GNU Affero General Public License 3.0.

This code was written for educational purposes only.

I, the writer of this code, cannot be kept responsible for damages caused by usage of this code for things including, but not limited to, somehow exploting Steam achievements or using this code on a public server for password phishing.
