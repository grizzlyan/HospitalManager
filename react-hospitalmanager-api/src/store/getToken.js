let accessToken ='';
let storageData = localStorage.getItem('userData');
let userData = JSON.parse(storageData)
if(userData!=null){
accessToken = userData.accessToken;
}

export const axiosConfig = {
    headers: {
        Authorization: `Bearer ${accessToken}`
    }
}

export const axiosImageConfig = {
    headers: {
        Authorization: `Bearer ${accessToken}`,
        "Content-Type": 'multipart/form-data'
    }
}

