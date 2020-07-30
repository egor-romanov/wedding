import HttpClient from '../utils/httpClient';

const endPoint = 'http://84.201.128.145/api/invite';

const getInvitationById = async id => {
  const httpClient = new HttpClient();
  try {
    const data = await httpClient.getAsyncS(`${endPoint}/${id}`);

    return data;
  } catch (error) {
    throw error;
  }
};

const setComingById = async (id, accept) => {
  const httpClient = new HttpClient();
  try {
    // eslint-disable-next-line no-undef
    const formData = new FormData();
    formData.append('accept', accept);
    const response = await httpClient.postAsyncS(`${endPoint}/${id}/accept`, formData);

    return response;
  } catch (error) {
    throw error;
  }
};

export default {
  getInvitationById,
  setComingById,
};
