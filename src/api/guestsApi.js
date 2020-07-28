import HttpClient from '../utils/httpClient';

const endPoint = `${process.env.VUE_APP_API_BACKEND}/api/guests`;

const getGuestById = async id => {
  const httpClient = new HttpClient();
  try {
    const data = await httpClient.getAsync(`${endPoint}/${id}`);
    return data;
  } catch (error) {
    throw error;
  }
};

const listGuests = async () => {
  const httpClient = new HttpClient();
  try {
    const data = await httpClient.getAsync(`${endPoint}`);
    return data;
  } catch (error) {
    throw error;
  }
};

const addGuest = async guest => {
  const httpClient = new HttpClient();
  try {
    const response = await httpClient.postAsyncS(`${endPoint}`, guest);

    if (response.length !== 0) {
      return response;
    }

    return response.data;
  } catch (error) {
    throw error;
  }
};

const addGuestLine = async (id, line) => {
  const httpClient = new HttpClient();
  try {
    const response = await httpClient.postAsyncS(`${endPoint}/${id}`, line);

    if (response.length !== 0) {
      return response;
    }
  } catch (error) {
    throw error;
  }
};

const searchUrl = `${endPoint}/Search?name=`;

export default {
  getGuestById,
  listGuests,
  addGuest,
  addGuestLine,
  searchUrl,
};
