import urllib3
import requests

urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)

url = "https://localhost:5001/api/commands/"

def test_add_command():
    json_data = {
        "HowTo": "ssh user@host",
        "Platfrom": "Linux",
        "Line": "ssh user@host"
    }
    http_res = requests.post(url, json=json_data, verify=False)
    print(http_res.content.decode())

test_add_command()