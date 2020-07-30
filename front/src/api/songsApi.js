import HttpClient from '../utils/httpClient';

const endPoint = 'http://romanovswedding.ru/api/songs';

const getSongs = async id => {
  const httpClient = new HttpClient();
  try {
    const data = await httpClient.getAsyncS(`${endPoint}`);

    return data;
  } catch (error) {
    throw error;
  }
};

const addSong = async (name, ordered) => {
  const httpClient = new HttpClient();
  try {
    // eslint-disable-next-line no-undef
    const formData = new FormData();
    formData.append('name', name);
    formData.append('ordered', ordered);
    const response = await httpClient.postAsyncS(`${endPoint}`, formData);

    return response;
  } catch (error) {
    throw error;
  }
};

export default {
  getSongs,
  addSong,
};
