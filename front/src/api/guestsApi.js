import HttpClient from '../utils/httpClient';

const endPoint = 'http://romanovswedding.ru/api/guests';

const getGuestById = async id => {
  const httpClient = new HttpClient();
  try {
    const data = await httpClient.getAsyncS(`${endPoint}/${id}`);
    return data;
  } catch (error) {
    throw error;
  }
};

const listGuests = async () => {
  const httpClient = new HttpClient();
  try {
    const data = await httpClient.getAsyncS(`${endPoint}`);
    return data;
  } catch (error) {
    throw error;
  }
};

const addGuestLine = async (id, line) => {
  const httpClient = new HttpClient();
  try {
    // eslint-disable-next-line no-undef
    const formData = new FormData();
    formData.append('comment', line);
    const response = await httpClient.postAsyncS(`${endPoint}/${id}/comment`, formData);

    return response;
  } catch (error) {
    throw error;
  }
};

export default {
  getGuestById,
  listGuests,
  addGuestLine,
};
